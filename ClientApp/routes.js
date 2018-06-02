import HomePage from 'components/home-page'
import Aloha from 'components/aloha'

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/aloha', component: Aloha, display: 'Aloha', style: 'glyphicon glyphicon-th-list' }
]
