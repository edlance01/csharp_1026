

using AttributeExampleOne;

ToolBox toolBox = new ToolBox();

toolBox.OldMethod(); // This will generate a compiler warning due to the Obsolete attribute

toolBox.NewMethod();