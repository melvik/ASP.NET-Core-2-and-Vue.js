<template>
  <div class="filters mb-4">
    <h5 class="mt-4">Filters</h5>
    <b-btn variant="outline-secondary" @click.prevent="reset">
    <i class="fas fa-sync mr-2"></i> Reset</b-btn>
    <b-list-group class="mt-4">
      <!-- our list of filter accordions will go here... -->
      <filter-accordion>
        <span slot="header">Brand</span>
        <multi-select-filter slot="body" query-key="brands" :items="filters.brands" />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Price</span>
        <range-filter slot="body" 
          :min="0"
          :max="1000"
          :interval="50"
          formatter="${value}"
          min-query-key="minPrice"
          max-query-key="maxPrice"
        />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Screen size</span>
        <range-filter slot="body"
            :min=0
            :max=7
            formatter="{value} in"
            min-query-key="minScreen"
            max-query-key="maxScreen"
        />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Capacity</span>
        <multi-select-filter slot="body" query-key="capacity" :items="filters.storage" />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Color</span>
        <multi-select-filter slot="body" query-key="colours" :items="filters.colours" />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Operating system</span>
        <multi-select-filter slot="body" query-key="os" :items="filters.os" />
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Features</span>
        <multi-select-filter slot="body" query-key="features" :items="filters.features" />
      </filter-accordion>
    </b-list-group>
  </div>
</template>

<script>
import FilterAccordion from "./FilterAccordion.vue"
import MultiSelectFilter from "./MultiSelectFilter.vue"
import RangeFilter from "./RangeFilter.vue"

export default {
  name: "filters",
  props: {
    filters: {
      type: Object,
      required: true
    }
  },
  components: {
    FilterAccordion,
    MultiSelectFilter,
    RangeFilter
  },
computed: {
    brands() {
        return this.$route.query.brands || ""
    },
    price() {
        return [
        this.$route.query.minPrice || 0,
        this.$route.query.maxPrice || 1000
        ]
    },
    screenSize() {
        return [
        this.$route.query.minScreen || 0,
        this.$route.query.maxScreen || 7
        ]
    },
    capacity() {
        return this.$route.query.capacity || ""
    },
    colours() {
        return this.$route.query.colours || ""
    },
    os() {
        return this.$route.query.os || ""
    },
    features() {
        return this.$route.query.features || ""
    }
  },
    methods: {
        reset() {
            this.$router.push({ query: {} })
        },
        clearBrands() {
            if (this.brands.length) {
                let query = Object.assign({}, this.$route.query)
                delete query.brands

                this.$router.push({ query: query })
            }
        },
        filterBrand(brand) {
            let query = Object.assign({}, this.$route.query)
            let split = query.brands ? query.brands.split("|") : []

            if (split.indexOf(brand) > -1) {
                let index = split.indexOf(brand)
                split.splice(index, 1)
            } else {
                split.push(brand)
            }

            if (split.length) {
                let joined = split.join("|")
                query.brands = joined
            } else {
                delete query.brands
            }

            this.$router.push({ query: query });
        },
        filterPrice(prices) {
            let query = Object.assign({}, this.$route.query);
            query.minPrice = prices[0]
            query.maxPrice = prices[1]

            this.$router.push({ query: query });
        },
        filterScreenSize(sizes) {
            let query = Object.assign({}, this.$route.query)
            query.minScreen = sizes[0]
            query.maxScreen = sizes[1]

            this.$router.push({ query: query })
        },
        clearCapacity() {
            if (this.capacity.length) {
                let query = Object.assign({}, this.$route.query)
                delete query.capacity

                this.$router.push({ query: query })
            }
        },
        filterCapacity(capacity) {
            let query = Object.assign({}, this.$route.query)
            let split = query.capacity ? query.capacity.split("|") : []

            if (split.indexOf(parsed) > -1) {
                let index = split.indexOf(parsed);
                split.splice(index, 1)
            } else {
                split.push(parsed)
            }

            if (split.length) {
                let joined = split.join("|")
                query.capacity = joined
            } else {
                delete query.capacity
            }

            this.$router.push({ query: query })
        },
        clearColours() {
            if (this.colours.length) {
                let query = Object.assign({}, this.$route.query);
                delete query.colours;

                this.$router.push({ query: query });
            }
        },
        filterColour(colour) {
            let query = Object.assign({}, this.$route.query);
            let split = query.colours ? query.colours.split("|") : [];

            if (split.indexOf(colour) > -1) {
                let index = split.indexOf(colour);
                split.splice(index, 1);
            } else {
                split.push(colour);
            }

            if (split.length) {
                let joined = split.join("|");
                query.colours = joined;
            } else {
                delete query.colours;
            }

            this.$router.push({ query: query });
        },
        clearOS() {
            if (this.os.length) {
                let query = Object.assign({}, this.$route.query);
                delete query.os;

                this.$router.push({ query: query });
            }
        },
        filterOS(os) {
            let query = Object.assign({}, this.$route.query);
            let split = query.os ? query.os.split("|") : [];

            if (split.indexOf(os) > -1) {
                let index = split.indexOf(os);
                split.splice(index, 1);
            } else {
                split.push(os);
            }

            if (split.length) {
                let joined = split.join("|");
                query.os = joined;
            } else {
                delete query.os;
            }

            this.$router.push({ query: query });
        },
        clearFeatures() {
            if (this.features.length) {
                let query = Object.assign({}, this.$route.query);
                delete query.features;

                this.$router.push({ query: query });
            }
        },
        filterFeature(feature) {
            let query = Object.assign({}, this.$route.query);
            let split = query.features ? query.features.split("|") : [];

            if (split.indexOf(feature) > -1) {
                let index = split.indexOf(feature);
                split.splice(index, 1);
            } else {
                split.push(feature);
            }

            if (split.length) {
                let joined = split.join("|");
                query.features = joined;
            } else {
                delete query.features;
            }

            this.$router.push({ query: query });
        }
    }
}
</script>
