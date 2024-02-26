using Newtonsoft.Json;

namespace LR5.Models
{
    public class GoogleSheetsEditResponse
    {
        public List<Request> Requests { get; set; }
    }

    public class Request
    {
        public RepeatCell RepeatCell { get; set; }
    }

    public class RepeatCell
    {
        public Range Range { get; set; }
        public Cell Cell { get; set; }
        public string Fields { get; set; }
    }

    public class Range
    {
        public int SheetId { get; set; }
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
        public int StartColumnIndex { get; set; }
        public int EndColumnIndex { get; set; }
    }

    public class Cell
    {
        public UserEnteredFormat UserEnteredFormat { get; set; }
    }

    public class UserEnteredFormat
    {
        public BackgroundColor BackgroundColor { get; set; }
        public TextFormat TextFormat { get; set; }
    }

    public class BackgroundColor
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }
    }

    public class TextFormat
    {
        public bool Bold { get; set; }
    }

}
