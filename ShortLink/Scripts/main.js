$(document).ready(function () {
    
    $('#addUrl').submit(function () {
        $.post('/Home/AddUrl', $('#addUrl').serialize(), function (data) {
            $('#links').html(data);
            $('#addUrl').each(function () {
                this.reset();
            });
        });
        return false;
    });
});