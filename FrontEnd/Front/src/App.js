import React, { Component } from 'react';
import './css/pure-min.css';
import './css/side-menu.css';
import { FormularioAutor, TabelaAutores } from './Cadastro';
import AutorBox from './Cadastro';
import PubSub from 'pubsub-js';
import { Link } from 'react-router'
class App extends Component {

  render() {
    return (
      <div id="layout">

        <a href="#menu" id="menuLink" className="menu-link">

          <span></span>
        </a>

        <div id="menu">
          <div className="pure-menu">
            <a className="pure-menu-heading" href="#">Menu</a>

            <ul className="pure-menu-list">
              <li className="pure-menu-item"><Link to="/" className="pure-menu-link">Home</Link></li>
              <li className="pure-menu-item"><Link to="/cadastra" className="pure-menu-link">Cadastra Amigo</Link></li>
              <li className="pure-menu-item"><Link to="/Localiza" className="pure-menu-link">Busca Amigos</Link></li>
            </ul>
          </div>
        </div>

        <div id="main">


          <div className="content" id="content">
            <div className="header">
              <h1> Amigos Mais Proximo</h1>
            </div>
            {this.props.children}
          </div>
        </div>


      </div>
    );
  }
}

export default App;
