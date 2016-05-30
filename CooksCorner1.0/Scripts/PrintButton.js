$(document).on('click', '#printButton', function () {
    var divContense = $('#DetailsRecipe').html();
    var printWindow = window.open(",", 'height = 400, width = 800');
    
    printWindow.document.write('<html><head><title>A cooks Corner Recipe</title></head>')
    printWindow.document.write('<body>', divContense,'</body>')
    printWindow.document.close()
    printWindow.print();
    printWindow.window.close();
    
    
})