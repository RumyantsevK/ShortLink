$(document).ready(function () {
    
    $('#addUrl').submit(function () {
        $.post('/Home/AddUrl', $('#addUrl').serialize(), function (data) {
            console.log(data);
            if ($('#url').val() !== '') {
                $('#links').append(data);
            }
            else {
                $('#links').html(data);
            }
            $('#addUrl').each(function () {
                this.reset();
            });
        });
        return false;
    });
});