var dataTable;

$(document).ready(function (){
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#FundProjTable').DataTable({
        "ajax": {
            "url": "/Admin/ResumeTemplates/GetAll"
        },
        "columns": [
            { "data": "projectName", "width": "15%" },
            { "data": "projCategory.categoryName", "width": "15%" },
            { "data": "goalAmount", "width": "15%" },
            { "data": "userAccountId", "width": "15%" },
            { "data": "createdDate", "width": "15%" },
        ]
    });
}