using System;
namespace test.Controls
{
    public class CardColumnTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Column1 { get; set; }
        public DataTemplate Column2 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Note)item).Index % 2 == 0 ? Column1 : Column2;
        }
    }
}

