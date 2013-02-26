using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Pkc.FDADownload.Properties;

namespace Pkc.FDADownload
{
class Program
{
static void Main (string [] args)
{
  ////////////////////////////////////////////
  // Download and extract FDA drug data files.
  ////////////////////////////////////////////

  string strFSrc = Properties.Settings.Default.strUriFDA;
  string strFTgt = Path.Combine (Environment.CurrentDirectory,"drugsatfda.zip");

  WebClient client = new WebClient ();
  client.DownloadFile (strFSrc,strFTgt);
  client.Dispose ();

  ProcessStartInfo PInfo = new ProcessStartInfo ("wzunzip");
  PInfo.Arguments = "-f \"" + strFTgt + "\" \"" + Path.GetDirectoryName (strFTgt) + "\"";

  Process.Start (PInfo).WaitForExit ();
  File.Delete (strFTgt);
}
}
}
