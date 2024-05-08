var dtable;

$(document).ready(function () {
    dtable = $('#mytable').DataTable({
    
            data: data,
            columns: [
                { data: 'name' },
                { data: 'position' },
                { data: 'salary' },
                { data: 'office' }
            ]
       

    });
});