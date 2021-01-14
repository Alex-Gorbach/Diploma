using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using WindowsFormsApp1.Core.Recepies;
using WindowsFormsApp1.Core.Servise;

namespace WindowsFormsApp1.Core.Edimdoma
{
    public class EdimdomaParser : IParser<string[]>
    {
        public ArborioModel ParseData( IHtmlDocument document )
        {
            var recipe = document.QuerySelector( "#mainWrapper" );
            var arborioModel = new ArborioModel();
            if (recipe != null)
            {

                var service = new ParserServise();
                service.InitCollection( arborioModel );
                var recipeName = recipe.QuerySelector( ".detailed" ).TextContent;
                arborioModel.Name = recipeName;
               
                var descriptions = recipe.QuerySelector("[itemprop=recipeInstructions]");
                if (descriptions != null) {
                    var descriptinfo = descriptions.QuerySelectorAll( "div" ).Where(
                        item =>  item.ClassName == "detailed_step_description_big" );
                    foreach (var item in descriptinfo)
                    {
                        arborioModel.Description += item.TextContent + "\n";
                    }
                }

                var imghref = recipe.QuerySelector( ".bigImgBox > a:nth-child(1) > img:nth-child(1)" ).GetAttribute( "src" );
                if (imghref != null) { 
                arborioModel.ImageHref = imghref;
                }
                var consist = document.QuerySelector( ".ingredients_wrapper" );

                var productsIinfo = consist.QuerySelectorAll( "li" )
                    .Where( item => item.ParentElement.ClassName != null
                    && item.ParentElement.ClassName.Contains( "detailed_ingredients" )
                    );

                var productsNameList = new List<string>();
                var productsUnitsList = new List<string>();

                for (int i = 0; i < productsIinfo.Count(); i++)
                {
                    var product = productsIinfo.ElementAt( i ).GetAttribute( "rel" );
                    productsNameList.Add( product );
                    
                    var number = productsIinfo.ElementAt( i ).TextContent.Replace( "—", "" );
                    var resultNumber = number.Replace( product, "" );
                    resultNumber.TrimStart();
                    productsUnitsList.Add( resultNumber );

                }


                arborioModel.Number = productsUnitsList;
                arborioModel.Products = productsNameList;
            }
            return arborioModel;
        }

        public string[] ParseHref( IHtmlDocument document )
        {
            var pageHrefs = new List<string>();
            var recipese = document.QuerySelector( ".cont_area" );
            var items = recipese.QuerySelectorAll( "a" )
                .Where( item => item.ClassName != null
                 && item.ClassName.Contains( "listRecipieTitle" )
                 );
            foreach (var item in items)
            {
                pageHrefs.Add( item.GetAttribute( "href" ) );
            }
            return pageHrefs.ToArray();
        }

        public string[] ParseImageHrefs( IHtmlDocument document )
        {
            var pageHrefs = new List<string>();
            var recipese = document.QuerySelector( ".cont_area" );
            var items = recipese.QuerySelectorAll( "img" )
                .Where( item => item.ParentElement.ClassName != null
                 && item.ParentElement.ClassName == "card__picture" );
            foreach (var item in items)
            {
                var imgHref = item.GetAttribute( "src" ).Replace( "small", "wide" );
                pageHrefs.Add( imgHref );
            }
            return pageHrefs.ToArray();
        }
    }
}
