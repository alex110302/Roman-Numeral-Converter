

using RomanConverter.Logic;

namespace RomanConverter;

public partial class MainPage : ContentPage
{
    private Converter converter;
    
    public MainPage()
    {
        converter = new Converter();
        InitializeComponent();
    }

    bool isDecimalConversion;

    private void BtnConvert_OnClicked(object sender, EventArgs e)
    {

        if (!isDecimalConversion)
        {
            if (converter.RomanToNumber(txtRoman.Text) == -1) DisplayAlert("Error", "Please enter only roman numerals", "Ok");
            else txtDecimal.Text = converter.RomanToNumber(txtRoman.Text).ToString();
        }
        else
        {
            if (int.TryParse(txtDecimal.Text, out int number)) txtRoman.Text = converter.NumberToRoman(number);
            else DisplayAlert("Error", "Please enter only integers", "Ok");
        }
    }

    private void TxtDecimal_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        isDecimalConversion = true;
    }

    private void TxtRoman_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        isDecimalConversion = false;
    }
}