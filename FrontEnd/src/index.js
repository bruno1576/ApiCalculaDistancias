import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import CadastroBox from './Cadastro';
import LocalizaBox from './Localiza';
import Home from './Home';
import { Router, Route, browserHistory, IndexRoute } from 'react-router';


ReactDOM.render(
    (<Router history={browserHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={Home} />
            <Route path="/cadastra" component={CadastroBox} />
            <Route path="/Localiza" component={LocalizaBox} />
        </Route>
    </Router>),
    document.getElementById('root')
);

