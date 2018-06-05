import HomePage from 'components/home-page'
import Aloha from 'components/aloha-simulator'

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/aloha_simulator', component: Aloha, display: 'Aloha', style: 'glyphicon glyphicon-th-list' },
]
