using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Eland.NRSM.Web.Areas.BaaSMng
{
    public class BaaSMngBundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            string languageName = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            #region :. Lightbox ( script: "~/bundles/plugins/lightbox" , css: "~/Areas/BaaSMng/Content/public/lightbox/bundle" )
            bundles.Add(new ScriptBundle("~/bundles/plugins/lightbox").Include(
                "~/Areas/BaaSMng/Scripts/plugins/lightbox/jquery.lightbox-0.5-custom.js"
                ));
            bundles.Add(new StyleBundle("~/Content/public/lightbox/bundle").Include(
                "~/Areas/BaaSMng/Scripts/plugins/lightbox/jquery.lightbox-0.5-custom.css"
                , "~/Areas/BaaSMng/Scripts/plugins/lightbox/jquery.lightbox-custom.css"
                ));
            #endregion

            #region :. jquery Validate ( "~/bundles/plugins/validate" )
            bundles.Add(new ScriptBundle("~/bundles/plugins/validate").Include(
                "~/Areas/BaaSMng/Scripts/plugins/validate/jquery.validate.js"
                , String.Format("~/Areas/BaaSMng/Scripts/plugins/validate/lang/validate-{0}.js", languageName)
                ));
            #endregion

            #region :. ckeditor ~/bundles/plugins/ckeditor
            // jquery ckeditor
            bundles.Add(new ScriptBundle("~/bundles/plugins/ckeditor").Include(
                "~/Areas/BaaSMng/Scripts/plugins/ckeditor/ckeditor.js"
                , "~/Areas/BaaSMng/Scripts/plugins/ckeditor/adapters/adapterjquery.js"
                , "~/Areas/BaaSMng/Scripts/plugins/ckeditor/jquery.wf.ckeditor.js"
                , String.Format("~/Areas/BaaSMng/Scripts/plugins/ckeditor/lang/{0}.js", languageName)
                ));
            #endregion

            #region :. default "~/bundles/public" , "~/Areas/BaaSMng/Content/public/bootstrap/bundle"
            // default javascript
            bundles.Add(new ScriptBundle("~/bundles/public").Include(
                "~/Areas/BaaSMng/Scripts/public/jquery-1.9.1.js"
                , "~/Areas/BaaSMng/Scripts/public/jquery-ui/jquery-ui-1.10.0.js"
                , "~/Areas/BaaSMng/Scripts/public/bootstrap/bootstrap*"
                , "~/Areas/BaaSMng/Scripts/public/i18next-1*"
                , "~/Areas/BaaSMng/Scripts/public/spin.*"
                , "~/Areas/BaaSMng/Scripts/public//common/common.js"
                , "~/Areas/BaaSMng/Scripts/public/wf/jquery.wf.*"
                , String.Format("~/Areas/BaaSMng/Scripts/public/wf/lang/jquery.wf.popup-{0}.js", languageName)
                , String.Format("~/Areas/BaaSMng/Scripts/public/common/lang/common-{0}.js", languageName)
                ));

            // default css
            bundles.Add(new StyleBundle("~/Content/public/bootstrap/bundle").Include(
                "~/Areas/BaaSMng/Content/public/bootstrap/bootstrap.css"
                , "~/Areas/BaaSMng/Content/public/bootstrap/bootstrap-responsive.css"
                , "~/Areas/BaaSMng/Content/public/bootstrap/bootstrapSwitch.css"
                , "~/Areas/BaaSMng/Content/themes/base/jquery.ui.css"
                , "~/Areas/BaaSMng/Content/StyleSheets/Site.css"
                , "~/Areas/BaaSMng/Content/StyleSheets/wf.popup.css"
                ));
            #endregion

            #region :. innoap "~/bundles/plugins/innoap"

            bundles.Add(new ScriptBundle("~/bundles/plugins/innoap").Include(
                "~/Areas/BaaSMng/Scripts/plugins/innoap/InnoAP.js"
                ));
            #endregion

            #region :. DataTables "~/Areas/BaaSMng/Content/plugins/dataTables" , "~/Areas/BaaSMng/Scripts/plugins/dataTables"

            bundles.Add(new StyleBundle("~/Content/plugins/dataTables/bundle").Include(
                "~/Areas/BaaSMng/Content/plugins/datatables/datatables.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/plugins/dataTables/bundle").Include(
                "~/Areas/BaaSMng/Scripts/plugins/datatables/jquery.dataTables.js",
                "~/Areas/BaaSMng/Scripts/plugins/datatables/jquery.dataTables.bootstrap.js",
                "~/Areas/BaaSMng/Scripts/plugins/datatables/jquery.dataTables.BaaS.js"
                ));
            #endregion

            #region :. JQuery Tree

            bundles.Add(new StyleBundle("~/Content/plugins/jqtree").Include(
                "~/Areas/BaaSMng/Scripts/plugins/tree/jqtree.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/plugins/jqtree").Include(
                "~/Areas/BaaSMng/Scripts/plugins/tree/tree.jquery.js"
                ));

            #endregion
        }
    }
}