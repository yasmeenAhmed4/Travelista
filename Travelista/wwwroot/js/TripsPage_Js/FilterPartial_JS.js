
        //Save The Date Input In the Session Storage Because When call the action will load the page again
        function updateMinPriceValue()
        {
            $('#minLabel').text("Min Price:  " + $('#minPrice').val());
        }

        function updateMaxPriceValue()
        {
            $('#maxLabel').text("Max Price:  " + $('#maxPrice').val());
        }

        //Reset All Data To the Default value
        function resetFilters()
        {
            $('#minPrice').val($('#minPrice').attr('min'));
            $('#maxPrice').val($('#maxPrice').attr('max'));
            $('#Category').prop('selectedIndex', 0);
            $('#Country').prop('selectedIndex', 0);
            $('#Date').val('');
        }

        //Before the Window Load
        window.onbeforeunload = function ()
        {
            sessionStorage.setItem("minPrice", $('#minPrice').val());
            sessionStorage.setItem("maxPrice", $('#maxPrice').val());
            sessionStorage.setItem("Category", $('#Category').prop('selectedIndex'));
            sessionStorage.setItem("Country", $('#Country').prop('selectedIndex'));
            sessionStorage.setItem("Date", $('#Date').val());
        };

        // OnLoad Page-->Load the Filter Data
        window.onload = function ()
        {
           
            $('#minPrice').val(sessionStorage.getItem("minPrice"));
            $('#maxPrice').val(sessionStorage.getItem("maxPrice"));
            $('#Category').prop('selectedIndex', sessionStorage.getItem("Category"));
            $('#Country').prop('selectedIndex', sessionStorage.getItem("Country"));
            $('#Date').val(sessionStorage.getItem("Date"));
            updateMinPriceValue();
            updateMaxPriceValue();
        };