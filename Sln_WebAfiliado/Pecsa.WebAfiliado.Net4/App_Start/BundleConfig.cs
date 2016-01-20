using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Pecsa.WebAfiliado.Net4.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/pageCss").Include(
                "~/Content/main.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/pageJs").Include(
                 "~/Scripts/plugins/spinner/jquery.mousewheel.js",
                 "~/Scripts/plugins/charts/excanvas.min.js",
                 "~/Scripts/plugins/charts/jquery.sparkline.min.js",
                 "~/Scripts/plugins/forms/uniform.js",
                 "~/Scripts/plugins/forms/jquery.cleditor.js",
                 "~/Scripts/plugins/forms/jquery.validationEngine-en.js",
                 "~/Scripts/plugins/forms/jquery.validationEngine.js",
                 "~/Scripts/plugins/forms/jquery.tagsinput.min.js",
                 "~/Scripts/plugins/forms/jquery.autosize.js",
                 "~/Scripts/plugins/forms/jquery.maskedinput.min.js",
                 "~/Scripts/plugins/forms/jquery.dualListBox.js",
                 "~/Scripts/plugins/forms/jquery.inputlimiter.min.js",
                 "~/Scripts/plugins/forms/chosen.jquery.min.js",
                 "~/Scripts/plugins/wizard/jquery.form.js",
                 "~/Scripts/plugins/wizard/jquery.validate.js",
                 "~/Scripts/plugins/wizard/jquery.form.wizard.js",
                 "~/Scripts/plugins/uploader/plupload.js",
                 "~/Scripts/plugins/uploader/plupload.html5.js",
                 "~/Scripts/plugins/uploader/plupload.html4.js",
                 "~/Scripts/plugins/uploader/jquery.plupload.queue.js",
                 "~/Scripts/plugins/tables/datatable.js",
                 "~/Scripts/plugins/tables/tablesort.min.js",
                 "~/Scripts/plugins/tables/resizable.min.js",
                 "~/Scripts/plugins/ui/jquery.tipsy.js",
                 "~/Scripts/plugins/ui/jquery.collapsible.min.js",
                 "~/Scripts/plugins/ui/jquery.prettyPhoto.js",
                 "~/Scripts/plugins/ui/jquery.progress.js",
                 "~/Scripts/plugins/ui/jquery.timeentry.min.js",
                 "~/Scripts/plugins/ui/jquery.colorpicker.js",
                 "~/Scripts/plugins/ui/jquery.jgrowl.js",
                 "~/Scripts/plugins/ui/jquery.breadcrumbs.js",
                 "~/Scripts/plugins/ui/jquery.sourcerer.js",
                 "~/Scripts/plugins/jquery.fullcalendar.js",
                 "~/Scripts/plugins/jquery.elfinder.js",
                 "~/Scripts/custom.js"));
        }
    }
}