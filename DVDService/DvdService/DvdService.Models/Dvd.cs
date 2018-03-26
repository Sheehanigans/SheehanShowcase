using DvdService.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DvdService.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }

        [TitleLengthVerification]
        public string Title { get; set; }

        [ReleaseYearValidation]
        public int ReleaseYear { get; set; }

        [DirectorValidation]
        public string Director { get; set; }

        [RatingValidation]
        public string  Rating { get; set; }

        [NotesValidation]
        public string Notes { get; set; }
    }
}
