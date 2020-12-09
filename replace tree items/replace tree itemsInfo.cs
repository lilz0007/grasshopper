using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace replace_tree_items
{
	public class replacetreeitemsInfo : GH_AssemblyInfo
  {
    public override string Name
	{
		get
		{
			return "replacetreeitems";
		}
	}
	public override Bitmap Icon
	{
		get
		{
			//Return a 24x24 pixel bitmap to represent this GHA library.
			return null;
		}
	}
	public override string Description
	{
		get
		{
			//Return a short string describing the purpose of this GHA library.
			return "";
		}
	}
	public override Guid Id
	{
		get
		{
			return new Guid("4c3a3f8f-929f-4f28-ac61-43195b90ed95");
		}
	}

	public override string AuthorName
	{
		get
		{
			//Return a string identifying you or your company.
			return "";
		}
	}
	public override string AuthorContact
	{
		get
		{
			//Return a string representing your preferred contact details.
			return "";
		}
	}
}
}
