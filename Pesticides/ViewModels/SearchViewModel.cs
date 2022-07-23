namespace Pesticides.ViewModels
{
    using Pesticides.Models;
    using System;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SearchViewModel()
        {

        }

        public int PesticideTypefk { get; set; }
        public int ActiveIngredientfk { get; set; }
        public int Cropfk { get; set; }
        public int Pestfk { get; set; }

        public List<int> selectedTypes { get; set; }
        public List<int> selectedActIngredients { get; set; }
        public List<int> selectedCrops { get; set; }
        public List<int> selectedPests { get; set; }

        public virtual IEnumerable<PesticidesInfo> PesticidesInfoes { get; set; }

        public IEnumerable<PesticideType> pesticideTypes { get; set; }
        public IEnumerable<ActiveIngredient> activeIngredients { get; set; }
        public IEnumerable<Crop> crops { get; set; }
        public IEnumerable<Pest> pests { get; set; }

    }

    public class AllSearchViewModel{
        public List<SearchViewModel> searchRecords { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}