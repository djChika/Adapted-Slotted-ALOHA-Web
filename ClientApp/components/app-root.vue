<template>
    <div id="app">
        <div class="container">
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
    import Vue from 'vue'
    import HomePage from './home-page'
    import Aloha from './aloha'


    Vue.component('home-page', HomePage);
    Vue.component('aloha', Aloha);

    export default {
        data() {
            return {
            }
        }
    }
</script>
<style>

</style>
