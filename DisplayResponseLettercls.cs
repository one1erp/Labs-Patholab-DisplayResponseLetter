using System;
using System.Collections;
using System.Windows.Forms;
using LSExtensionExplorer;


namespace DisplayResponseLetter
{


    public partial class DisplayResponseLettercls : UserControl, ILSXplDetailsControl
    {

        public DisplayResponseLettercls()
        {

            InitializeComponent();
          
        }




        public event ExceptionThrownEventHandler ExceptionThrown;

        public void PreDisplay()
        {

            ExceptionThrown += DisplayResponseLettercls_ExceptionThrown;
            //   SelectionChanged(null);


        }
        private void InitializeAdobe(string filePath)
        {
            try
            {
              
               
                axAcroPDF1.Dock=DockStyle.Fill;
                this.axAcroPDF1.LoadFile(filePath);
                this.axAcroPDF1.src = filePath;
                this.axAcroPDF1.setShowToolbar(false);
                this.axAcroPDF1.setView("FitH");
                this.axAcroPDF1.setLayoutMode("SinglePage");
                this.axAcroPDF1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        void DisplayResponseLettercls_ExceptionThrown(object sender, Exception e)
        {
            MessageBox.Show("Error 2 ");
        }

        private bool b;
        public void SelectionChanged(ArrayList[] selectionList)
        {
            try
            {


                var param = selectionList[1];
                var fileName = param[0].ToString().Split('/')[0];

                InitializeAdobe(@"C:\DetailsExt\" + fileName + ".pdf");
            }
            catch (Exception)
            {

            }
        }

        public void SetServiceProvider(object serviceProvider)
        {


        }


    }
}