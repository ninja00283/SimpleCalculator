using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        //InputField0 carries the first number of the sum.
        string[] InputField = new string[] { "", "" };

        //Operator carries the operator of the equation.
        string Operator = "";

        //Current input field
        int CurrentInput = 0;

        //Initialize Form1.
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// If a number button is clicked.
        /// Get the button that was pressed.
        /// Get the text(number) on the button.
        /// add the input(Inputnumber) to the screen.
        ///
        /// </summary>
        /// <param name="sender"> the button id </param>
        /// <param name="e"></param>
        private void numberButton_Click(object sender, EventArgs e)
        {

            Button NumberButton = (Button)sender;
            int Inputnumber = int.Parse(NumberButton.Text);


            AddNumberToInputFieldX(Inputnumber, CurrentInput);
        }

        /// <summary>
        /// 
        /// Set the operator to the text of the operator button
        /// 
        /// </summary>
        /// <param name="sender"> the button id </param>
        /// <param name="e"></param>
        private void OperatorButton_Click(object sender, EventArgs e)
        {

            Button OperatorButton = (Button)sender;
            string InputOperator = OperatorButton.Text;

            AddOperatorToInputFieldX(InputOperator);
        }


        /// <summary>
        /// 
        /// Add a number( int Number ) to the inputfield the given position( int InputField ).
        /// Convert the given number to a string and add it to the end of the appropriate InputField.
        /// Update fields.
        /// 
        /// </summary>
        /// <param name="NumberToAdd"> The number to add. </param>
        /// <param name="InputFieldPosition"> The Position in the array(InputField) to change. </param>
        /// <returns> return the edited InputField(String InputField). </returns>
        public string AddNumberToInputFieldX(int NumberToAdd, int InputFieldPosition) {
            InputField[InputFieldPosition] += NumberToAdd.ToString();
            updateInputFields();
            return InputField[InputFieldPosition];
        }

        /// <summary>
        /// 
        /// Set the selected operator as the operator.
        /// If the current input field(int CurrentInput) is the first field change the field.
        /// 
        /// </summary>
        /// <param name="OperatorToAdd"></param>
        /// <returns>The edited operator field(string Operator). </returns>
        public string AddOperatorToInputFieldX(string OperatorToAdd)
        {
            Operator = OperatorToAdd;
            updateInputFields();

            if (CurrentInput==0) { CurrentInput = 1; }

            return Operator;
        }


        /// <summary>
        ///
        /// Set every input field to the InputField text.
        ///
        /// </summary>
        private void updateInputFields() {
            InputField0.Text = InputField[0];
            InputField1.Text = InputField[1];

            OperatorField.Text = Operator;
        }

        /// <summary>
        /// 
        /// If the equals button is pressed solve the equation,
        /// then put the output in the dropdown box and change it as the selected item.
        /// 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetSum(object sender, EventArgs e)
        {
            float Output = 0;

            float Input1 = float.Parse(InputField[1]);

            if (ProcentBox.Checked) {
                Input1 = float.Parse(InputField[0]) / 100 * float.Parse(InputField[1]);
            }

            switch (Operator)
            {

                case "÷":
                    Output = float.Parse(InputField[0]) / Input1;
                    break;
                case "×":
                    Output = float.Parse(InputField[0]) * Input1;
                    break;
                case "-":
                    Output = float.Parse(InputField[0]) - Input1;
                    break;
                case "+":
                    Output = float.Parse(InputField[0]) + Input1;
                    break;
            }

            OutputDropDown.Items.Insert(0, Output.ToString());
            OutputDropDown.SelectedIndex = 0;
        }
        /// <summary>
        /// 
        /// If the selected item changed put the selected item in the output field.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            OutputField.Text = OutputDropDown.Text;
        }
        /// <summary>
        /// 
        /// If clicked on a input field set it as the current input field( int CurrentInput ).
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void field0_Click(object sender, EventArgs e)
        {
            CurrentInput = 0;
        }
        private void field1_Click(object sender, EventArgs e)
        {
            CurrentInput = 1;
        }

        /// <summary>
        /// 
        /// Remove last Character from current input field.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backSpace(object sender, EventArgs e)
        {
            if (InputField[CurrentInput].Length > 0)
            {
                InputField[CurrentInput]= InputField[CurrentInput].Remove(InputField[CurrentInput].Length - 1);
            }
            updateInputFields();
        }

        /// <summary>
        /// 
        /// Add a Decimal if there is none.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addDecimal(object sender, EventArgs e)
        {
            if (!InputField[CurrentInput].Contains(".") && InputField[CurrentInput].Length > 0)
            {
                InputField[CurrentInput] += ".";
            }
            
            updateInputFields();
        }


        /// <summary>
        /// 
        /// Parse the current input field reverse iot and convert it back to a string.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invert(object sender, EventArgs e)
        {
            InputField[CurrentInput] = (float.Parse(InputField[CurrentInput]) * -1).ToString();
            updateInputFields();
        }

        /// <summary>
        /// 
        /// Clear all the fields.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear(object sender, EventArgs e)
        {
            CurrentInput = 0;
            InputField[0] = "";
            InputField[1] = "";
            Operator = "";
            updateInputFields();
        }

        private void ProcentBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
