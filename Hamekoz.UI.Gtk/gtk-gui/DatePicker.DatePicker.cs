
// This file has been generated by the GUI designer. Do not modify.
namespace DatePicker
{
	public partial class DatePicker
	{
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Entry entry;
		
		private global::Gtk.Button button;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget DatePicker.DatePicker
			global::Stetic.BinContainer.Attach (this);
			this.Name = "DatePicker.DatePicker";
			// Container child DatePicker.DatePicker.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entry = new global::Gtk.Entry ();
			this.entry.CanFocus = true;
			this.entry.Name = "entry";
			this.entry.IsEditable = true;
			this.entry.InvisibleChar = '●';
			this.hbox1.Add (this.entry);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.button = new global::Gtk.Button ();
			this.button.CanFocus = true;
			this.button.Name = "button";
			this.button.UseUnderline = true;
			global::Gtk.Image w2 = new global::Gtk.Image ();
			w2.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "stock_calendar", global::Gtk.IconSize.Menu);
			this.button.Image = w2;
			this.hbox1.Add (this.button);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
