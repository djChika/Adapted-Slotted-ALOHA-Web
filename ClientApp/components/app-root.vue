<template>
    <div id="app">
        <div class="container">
            <Navbar></Navbar>
        </div>
        <div class="container">
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
    import Navbar from './nav-bar'
    import Vue from 'vue'
    import Aloha from './aloha-simulator'
    import HomePage from './home-page'

    Vue.component('Navbar', Navbar)
    Vue.component('aloha', Aloha);
    Vue.component('home-page', HomePage);

    export default {
        data() {
            return {
            }
        }
    }
</script>
<style>
</style>
