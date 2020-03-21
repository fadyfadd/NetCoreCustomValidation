
$(document).ready(function () {

    $('head').append(`
        <style>
            div#progressIndicator {
                width: 100%;
                height: 100%;
                top: 0px;
                left: 0px;
                position: fixed;
                display: block;
                opacity: 0.7;
                background-color: #fff;
                z-index: 10000;
                text-align: center;
                display: none;
            }

            .ball {
                position: fixed;
                left: calc((100% - 0px)/2);
                top: calc((110% -  0px)/2);
                animation: spin 0.8s infinite linear;

            }

            @keyframes spin {
                0% {
                    transform: rotate(0deg);
                }
                100% {
                    transform: rotate(360deg);
                }
                ;
            }

            @keyframes spinoff {
                0% {
                    transform: rotate(0deg);
                }
                100% {
                    transform: rotate(-360deg);
                }
                ;
            }
        </style>   
    
    `);

    $('body').prepend(`
        <div id="progressIndicator">
            <i class="fas fa-spinner fa-3x ball"></i>
            <div class="ball1">
            </div>
        </div>    
    
    `);


    $('body').prepend(`
        <script language="javascript">
            let numberOfProgressIndicator = 0;

            function showProgress(options) {
                $("#progressIndicator").fadeIn("slow");
                numberOfProgressIndicator++;
            }

            function endProgress() {
                numberOfProgressIndicator--;

                if (numberOfProgressIndicator < 0)
                    numberOfProgressIndicator = 0;

                if (numberOfProgressIndicator == 0)
                    $("#progressIndicator").fadeOut("slow");
            }
        </script>
    `);

});



