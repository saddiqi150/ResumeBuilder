var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#ResumeTemplateTable').DataTable({
        "ajax": {
            "url": "/Admin/ResumeTemplates/GetAll"
        },
        "columns": [
            { "data": "templateName", "width": "15%" },
            { "data": "templateDescription", "width": "15%" },
            { "data": "createdDate", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <td>
                           <a class="btn btn-warning mx-2"
                               href="/Admin/ResumeTemplates/Upsert?id=${data}">
                           <i class="bi bi-pencil"></i> <span class="d-none
                                d-xl-inline">&nbsp; Edit</span></a>
                               <a onClick=Delete('/Admin/ResumeTemplates/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> &nbsp;Delete</a>
                        </td>
                        `
                }, "width": "22%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload()
                        toastr.success(data.message)
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalDeleteWithBootstrapButtons.fire(
                'Cancelled',
                'Your file was not deleted.',
                'info'
            )
        }
    })
}