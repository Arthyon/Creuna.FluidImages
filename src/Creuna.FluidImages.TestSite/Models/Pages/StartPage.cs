using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Creuna.FluidImages.TestSite.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "eeea0d5a-cdbc-4403-a906-d6e03883e3ae", Description = "")]
    public class StartPage : PageData
    {
        [UIHint(EPiServer.Web.UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [UIHint(EPiServer.Web.UIHint.Image)]
        public virtual ContentReference SecondImage { get; set; }
    }
}