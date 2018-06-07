<template>
    <nav id="navbar" class="navbar navbar-expand-sm bg-primary navbar-dark rounded-bottom">
        <router-link class="navbar-brand" to="/">
            <img class="mr-auto mb-1" id="appicon" src="../static/orbit-icon-19.jpg"
                 width="30" height="30" />
            Adapted Slotted ALOHA
        </router-link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <router-link class="nav-link" to="/aloha_simulator">Simulator <span class="sr-only">(current)</span></router-link>
                </li>
            </ul>
        </div>
    </nav>
</template>
<script>

</script>
<style>
    #navbar {
        background: linear-gradient(to bottom right, rgba(83,0,255), rgba(200,0,255));
        opacity: 0.75;
        max-height:50px;
    }

    #appicon {
        filter: brightness(0) invert(1);
    }
</style>
