using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace xrmtoolbox_SetDefaultView
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Set User Default View"),
        ExportMetadata("Description", "Set User Default View"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAABSlBMVEVHcEzhP3IfyO1sFifDN2oCdM8QL2MdFDBWMmeZ4bMQxNyMy6a/L3DJvO5mPn/jMncAAAAAChi+OXsGjs4DU5wbW6AEquYEO5NsIksFfesBftYeUoyONnIkYZEVZ6f/v21lH0cIc8UMd8cghtYdn9/iXmr3cl2mNWq9SXIJc7g7Rn3/smZ46MP/l11TmMcNdbG/emdyz6x7n7GE1K19vJyNmoBblZSItqd2sJeMK1yYKl2XO1NyP2ZHO2mCQG62Um8RPm84f5RdraoGNmoRRYonP1zTbmEteblteruHX3/ZXmVtT4SdTVWhQ3zYd2KGeHlnXXSsW48rVok3NF5Hdp2RH04GY64YS5E1Z5ERgZEGHzoEXYgvMFUfb6zcl3saSWbCvpBqXHd3WW6zRFwopazEaWxLvrPBq3yNq74aWnwHYKdHoZhSg5Mohai7nNoBAAAAOXRSTlMACRABPx2MaP0cI8opAkpmBiS0VWBTRAp4DznV9+u5Ed1dpLJytDf58MLzOi5RxfrqseSBZbn65vAkQYV1AAAArUlEQVQY02NgwA6YuLiYkLicxtzmRnoqcCEd7oS4VPtAD2VWMFee0zDdLSnH0dXWXUkcJKBtYuGWmOaUnRITrK8IEtA1NUvOdcqIj4wItdWUBAqoGTjaxGa6RkWHWFtpSQEFGFU9g1yynB3C/H04ZESBAswsGt4Ozi7hAX42ckJ8IEOYJdR97ezsvaxlxfh5wBYLsCtYWllySAvzsjBCnSbIzsYmwsrAzMhADgAAW50bLQhA2KAAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#cfedf8"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new SetUserDefaultViewControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}