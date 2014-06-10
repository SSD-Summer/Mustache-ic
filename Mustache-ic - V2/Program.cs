using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Mustashe_ic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        


        static void Main()
        {
            System.Windows.Forms.ImageList imageList;
            imageList = new System.Windows.Forms.ImageList();
            //imageList.Images.Add(
            //    Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bird.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\chicken.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\bronc.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\cat.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\crab.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\dog.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\goldfish.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\pig.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\jellyfish.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\sheep.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\steg.jpg"));
            //imageList.Images.Add(
            //   Image.FromFile("C:\\Users\\Russ\\Documents\\GitHub\\Mustache-ic\\images\\t_rex.jpg"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new gameMain());

        }
    }
    public static class imageList
    {
        static imageList()
        {
            ImageList imageList_animals = new System.Windows.Forms.ImageList();
            ImageList imageList_moustache = new System.Windows.Forms.ImageList();

        }


    }

}
