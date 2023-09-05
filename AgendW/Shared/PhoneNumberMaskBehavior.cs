using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendW.Shared
{
    public class PhoneNumberMaskBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (args.NewTextValue == args.OldTextValue)
                return;

            var entry = (Entry)sender;
            string text = args.NewTextValue;

            if (string.IsNullOrEmpty(text))
                return;

            // Replace this logic with your desired formatting logic
            if (text.Length == 3 || text.Length == 7)
            {
                entry.Text += "-";
            }
        }
    }

}
