

window.addEventListener("load", (event) =>
{
    const itemsPerPage = 3;
    let currentPage = 1;

    function showPage(pageNumber)
    {
        currentPage = pageNumber;
        $('.row .single-destinations').hide();
        //start Index Card For  Page
        var startIndex = (pageNumber - 1) * itemsPerPage;

        //End Index Card For Page
        var endIndex = startIndex + itemsPerPage;
        $('.row .single-destinations').slice(startIndex, endIndex).show();
        generatePagination();
    }

    function generatePagination()
    {
        var totalPages = Math.ceil($('.row .single-destinations').length / itemsPerPage);
        var paginationHtml = '<ul class="pagination justify-content-center">';
        var startRange = Math.max(1, currentPage - 1);
        var endRange = Math.min(totalPages, startRange + 2);

        if (currentPage > 2) {
            paginationHtml += '<li class="page-item"><a href="#" class="page-link prev" style="font-size: 25px;" aria-label="Previous"><span aria-hidden="true">&laquo;</span><span class="sr-only">Previous</span></a></li>';
        }

        for (var i = startRange; i <= endRange; i++) {
            paginationHtml += '<li class="page-item"><a href="#" class="page-link page-number' + '" style="font-size: 25px;">' + i + '</a></li>';
        }

        if (currentPage < totalPages) {
            paginationHtml += '<li class="page-item"><a href="#" class="page-link next" style="font-size: 25px;" aria-label="Next"><span aria-hidden="true">&raquo;</span><span class="sr-only">Next</span></a></li>';
        }
        paginationHtml += '</ul>';
        $('#pagination').empty().html(paginationHtml);
    }


    $(document).on('click', '.pagination .page-number', function (event)
    {
        event.preventDefault();
        var pageNumber = parseInt($(this).text());
        showPage(pageNumber);
        var offsetTop = $('#pagination').offset().top - 600;
        $('html, body').animate({ scrollTop: offsetTop });
    });

    $(document).on('click', '.pagination .prev', function (event)
    {
        event.preventDefault();
        showPage(currentPage - 1);
        var offsetTop = $('#pagination').offset().top - 600;
        $('html, body').animate({ scrollTop: offsetTop });
    });

    $(document).on('click', '.pagination .next', function (event)
    {
        event.preventDefault();
        showPage(currentPage + 1);
    });

    showPage(1);
});



