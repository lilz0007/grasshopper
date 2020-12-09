using System;
using System.Collections;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace replace_tree_items
{

    
        public class replacetreeitemsComponent : GH_Component
        {
        
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public replacetreeitemsComponent()
              : base("DATATREEREPLACE", "LILZ",
                  "REPLACE ITEMS IN A DATATREE",
                  "lilZPLUGIN", "Primitive")
            {
            }
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("datatree", "datatree", "the datatree structure", GH_ParamAccess.tree);
            pManager.AddGenericParameter("listsearch", "listsearch", "the list of items the script will search for in your datatree and replace it", GH_ParamAccess.list);
            pManager.AddGenericParameter("listreplace", "listreplace", "the list of items the script will replace in your datatree based on the identical index between the search and replace list", GH_ParamAccess.list);
        }

        public override Grasshopper.Kernel.GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("the replaced datatree", "DATATREE-R", "the replaced datatree", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
            {



            GH_Structure<Grasshopper.Kernel.Types.IGH_Goo> datatree = null;
            List<IGH_Goo> listsearch=new List<IGH_Goo>();
            List<IGH_Goo> listreplace= new List<IGH_Goo>();
            
            if (!DA.GetDataTree( 0 , out datatree)) return;
            
            if (!DA.GetDataList(1, listsearch)) return;
            

            if (!DA.GetDataList(2, listreplace)) return;

            
            datatree.Insert(listsearch[0], datatree.get_Path(0), 0);
            for (int i = 0;  i < datatree.PathCount; i++)
            {
                   
              for (int j = 0; j < datatree.get_Branch(datatree.get_Path(i)).Count; j++)
                {
                    for (int h = 0; h < listsearch.Count; h++)
                    {
                        if (listsearch[h] == datatree.get_DataItem(datatree.get_Path(i),j))
                        {
                            datatree.Insert(listreplace[h], datatree.get_Path(i), j);
                        }
                    }
                }
            }
           

            // We're set to create the spiral now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:
            GH_Structure<Grasshopper.Kernel.Types.IGH_Goo> spiral = datatree;
            //IGH_StructureEnumerator spiral = datatree.AllData(true);

            // Finally assign the spiral to the output parameter.
            DA.SetDataTree(0, spiral);

        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return replace_tree_items.Properties.Resources.down.ToBitmap();
            }
        }


        public override Guid ComponentGuid
        {
            get { return new Guid("159297ee-6747-4f6d-aa87-92b24a72520d"); }
        }
    }
        }
    

