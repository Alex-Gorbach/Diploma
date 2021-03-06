﻿using AngleSharp.Parser.Html;
using System;
using WindowsFormsApp1.Core.Servise;

namespace WindowsFormsApp1.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        DataServise dataServise = new DataServise();
        HtmlLoader loader;

        bool isActive;

        #region Properties

        public IParser<T> Parser
        {

            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }

        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader( value );
            }
        }




        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;


        public ParserWorker( IParser<T> parser )
        {
            this.parser = parser;
        }

        public ParserWorker( IParser<T> parser, IParserSettings parserSettings ) : this( parser )
        {
            this.parserSettings = parserSettings;
        }

        public void Start( int index )
        {
            isActive = true;
            if (index == 1)
                Worker();
            if (index == 2)
                WorkerEdimDoma();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for (int i = parserSettings.StartPoint; i < parserSettings.EndPoint; i++)
            {
                if (!IsActive)
                {
                    OnCompleted?.Invoke( this );
                    return;
                }

                var source = await loader.GetSourceByPageId( i );
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync( source );
                var result = parser.ParseHref( document );
                var imgHrefs = parser.ParseImageHrefs( document );
                var resltimgHrefs = imgHrefs as string[];

                var resultHref = result as string[];

                if (resltimgHrefs.Length == resultHref.Length)
                    for (int j = 0; j < resultHref.Length; j++)
                    {
                        var recipeSource = await loader.GetRecipeByPageHref( resultHref[j] );
                        var recipeDocument = await domParser.ParseAsync( recipeSource );
                        var resulRecipe = parser.ParseData( recipeDocument );
                        if (resulRecipe.Description != null)
                        {
                            resulRecipe.ImageHref = resltimgHrefs[j];
                            await dataServise.Create( resulRecipe );
                        }
                    }


                OnNewData?.Invoke( this, result );

            }

            OnCompleted?.Invoke( this );
            isActive = false;
        }


        private async void WorkerEdimDoma()
        {
            for (int i = parserSettings.StartPoint; i < parserSettings.EndPoint; i++)
            {
                if (!IsActive)
                {
                    OnCompleted?.Invoke( this );
                    return;
                }

                var source = await loader.GetSourceByPageId( i );
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync( source );
                var result = parser.ParseHref( document );
                var resultHref = result as string[];
                for (int j = 0; j < resultHref.Length; j++)
                {
                    var recipeSource = await loader.GetRecipeByPageHref( resultHref[j] );
                    var recipeDocument = await domParser.ParseAsync( recipeSource );
                    var resulRecipe = parser.ParseData( recipeDocument );
                    if (resulRecipe.Description != null)
                    {
                        await dataServise.Create( resulRecipe );
                    }
                }

                OnNewData?.Invoke( this, result );
               
            }
            OnCompleted?.Invoke( this );
            isActive = false;
        }
    }
}




