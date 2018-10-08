using System.Collections.Generic;

namespace be_master_with_core2.Features.Filters
{
    internal class FiltersListViewModel
    {
        public List<string> Brands { get; set; }
        public List<string> Storage { get; set; }
        public List<string> Colours { get; set; }
        public List<string> OS { get; set; }
        public List<string> Features { get; set; }
    }
}