// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$(".detailPage").on('click', function (event) {
//    // Image that was clicked
//    //event.preventDefault();

//    //const btnImage = event.relatedTarget

//    // Get the photo id from data-bs-* attribute
//    const serviceId = $(this).data('service-id')


//    const apiUrl = '/servicedetail?id=' + serviceId

//    $.get(apiUrl, function (service) {
//        alert(service);
//        // Switch the image
//        const serviceUrl = '/servicephotos/' + service.fileName;
//        $('#detail-img').attr('src', serviceUrl)
//        alert(serviceUrl);
//        $('#service-name').text(service.serviceName)
//        alert(service.serviceName);
//        $('#service-description').text(service.description)
//        $('#service-price').text(service.price)

//    })
//})

//$.ajax({
//    url: apiUrl,
//    method: 'GET',
//    dataType: 'json',
//    success: function (service) {
//        console.log('Service Data:', service);
//        // Handle the service data as needed
//    },
//    error: function (xhr, status, error) {
//        console.error('Error:', error);
//    }
//});
