using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;
using ScriptPortal.Vegas;
namespace ScriptForms
{
    
}


public class EntryPoint
{
    public void FromVegas(Vegas vegas)
    {
        string rendererID = "a84b3f59-ae2f-4917-995d-2e3b97035b46";
        VideoEvent videoEvent = (VideoEvent)vegas.Project.Tracks[1].Events[0];

        AudioEvent audioEvent = (AudioEvent)vegas.Project.Tracks[0].Events[0];
        double playbackRate = 1;
        var videoEndPoint = videoEvent.End;
        vegas.Transport.LoopRegionLength = videoEndPoint;
        //audioEvent.End = videoEndPoint;

        //Renderer renderer = vegas.Renderers.FindByName("6 Mbps HD 720-30p Video");
        Renderer renderer = vegas.Renderers.FindByRendererID(13);
        RenderTemplate renderTemplate = renderer.Templates[0];

        
        for (int i = 0; i < 2; i++ )
        {

            videoEvent.PlaybackRate = playbackRate;
            playbackRate += 0.5;
            //videoEndPoint = videoEvent.End;
            vegas.Transport.LoopRegionLength = videoEndPoint;
            RenderArgs renderArgs = new RenderArgs() { OutputFile = "C:\\Programmi\\DotNet\\ScriptVegas\\ScriptForms\\", RenderTemplate = renderTemplate };
            string fileFormat = renderer.FileExtension;
            string fm = fileFormat.Trim('*');
            StringBuilder fileName =  new StringBuilder(String.Format("C:\\Programmi\\DotNet\\ScriptVegas\\ScriptForms\\rendered{0}{1}", (i + 1), fm));
            string fn = fileName.ToString();
            vegas.Project.Render(fn, renderTemplate, new Timecode(0), videoEndPoint );
            
            Timecode changedLentgh  = new Timecode(videoEvent.End.ToMilliseconds()/playbackRate);
            videoEndPoint = changedLentgh;
        }
    }
}