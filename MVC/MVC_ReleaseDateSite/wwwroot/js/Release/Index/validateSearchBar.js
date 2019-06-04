        let form = document.querySelector("#search-form");
        let searchBar = document.querySelector("#search-bar");
        form.onsubmit = (e) => {
            if (searchBar.value == "") {
                e.preventDefault();
            }
        };

        function SubmitFormIfSearchNotEmpty(){
            if (searchBar.value != "") {
                form.submit();
            }
        }