$('.selectchangetotal').on('change', function () {
    var quantity = $('#selectquantity').val();
    var price = $('#selectunitprice').val();
    var taxvalue = $('#selecttax').val();
    var tax = 18;
    if (taxvalue == 1) { tax = 8; }
    if (taxvalue == 2) { tax = 1; }
    if (taxvalue == 3) { tax = 0; }
    var aratoplam = (quantity * price);
    var kdv = ((quantity * price) * tax / 100);
    var total = aratoplam + kdv;
    var t = total.toFixed(2);
    var y = parseFloat(total).toFixed(2).replace(".", ",");

    $('#selecttotal').val(y);
    $('#spanaratoplam').text(aratoplam);
    $('#spankdv').text(kdv);
    $('#spantotal').text(total);
})

$(function () {
    $('.createtimepicker').datepicker({
        format: 'dd-MM-yyyy',
        autoclose: true,
        language: "tr"
    });
});

$("#productsearch").autocomplete({
    source: function (request, response) {
        $.get({
            url: '@Url.Action("GetSearchProductValue", "Invoice")',
            dataType: "json",
            data: {
                search: request.term,
            },
            success: function (data) {
                $('.newProduct').hide();
                response($.map(data, function (item) {
                    return { label: item.Name, value: item.Name };
                }));
            },
            error: function (xhr, status, error) {
                $('.newProduct').show();
                setTimeout(function () {
                    $('.newProduct').hide();
                }, 6000);
            }
        });
    }
});

