// function that get news
function getNews(repeaterIndex) {
        $.ajax({
            type: "POST",
            url: "Default.aspx/GetNewsByIndex",
            data: JSON.stringify({ index: repeaterIndex }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // response from the server
                const titleHtml = '<h3>' + response.d.Title + '</h3>';
                const DescriptionHtml = '<p>' + response.d.Description + '</p>';
                const linkHtml = '<a href="' + response.d.Link + '"target="_blank" id="readMore">Read more>></a>';
                $('#body-post').html(titleHtml + DescriptionHtml + linkHtml);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    }
