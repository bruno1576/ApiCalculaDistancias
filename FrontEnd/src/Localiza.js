
import React, { Component } from 'react';
import $ from 'jquery';
import InputCustomizado from './componentes/InputCustomizado';
import PubSub from 'pubsub-js';
export class Localiza extends Component {

  constructor() {
    super();
    this.state = { lista: [], Nome: '', X: '', Y: '' };
    this.enviaForm = this.enviaForm.bind(this);
    this.setNome = this.setNome.bind(this);
    this.setX = this.setX.bind(this);
    this.setY = this.setY.bind(this);
  }
  atualizaListagem(novaLista) {
    this.setState({ lista: novaLista });
  }

  enviaForm(evento) {

    evento.preventDefault();
    $.ajax({
      url: "http://localhost:51751/V1/LocalizacaoDoAmigo" + "/" + this.state.X + "/" + this.state.Y,
      contentType: 'application/json',
      crossDomain: true,
      dataType: 'json',
      type: 'get',
      data: {},
      headers: {
        'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJWYWxkaXIgRmVycmVpcmEiLCJqdGkiOiI1OTc1NWFkZC04YTc2LTQ0YTYtOTJlZS01YmMwMjc3NzQwYTgiLCJVc3VhcmlvQVBJTnVtZXJvIjoiMSIsImV4cCI6NjE1NzIxODgyMzAsImlzcyI6IlRlc3RlLlNlY3VyaXJ5LkJlYXJlciIsImF1ZCI6IlRlc3RlLlNlY3VyaXJ5LkJlYXJlciJ9.9n-Xbe1fiOxDxVkIXipzVHapj0Olcl64RFAQ8EYmXtY'
      },
      success: function (resposta) {


        PubSub.publish('atualiza-lista-autores', resposta);



      }.bind(this),
      error: function (resposta) {
        console.log('We are');
        console.log(resposta);
        alert(resposta.responseJSON.descricao);
      }

    });


  }

  setNome(evento) {
    this.setState({ Nome: evento.target.value });
  }

  setX(evento) {
    this.setState({ X: evento.target.value });
  }

  setY(evento) {
    this.setState({ Y: evento.target.value });
  }

  render() {

    return (
      <div className="pure-form pure-form-aligner">
        <form className="pure-form pure-form-aligned" onSubmit={this.enviaForm} method="post">
          <InputCustomizado id="X" type="text" name="X" value={this.state.X} onChange={this.setX} label="X" />
          <InputCustomizado id="idade" type="text" name="Y" value={this.state.Y} onChange={this.setY} label="Y" required />
          <div className="pure-control-group">
            <label></label>
            <button type="submit" className="pure-button pure-button-primary">Localiza</button>
          </div>
        </form>

      </div>
    );
  }

}
export class TabelaCadastro extends Component {

  render() {
    return (
      <div>
        <table className="pure-table">

          <thead>
            <tr>
              <th>Nome</th>
              <th>Distancia</th>
            </tr>
          </thead>

          {

            this.props.lista.map(function (lista) {

              return (

                <tbody>

                  <tr >
                    <td>{lista.nome}</td>
                    <td>{lista.total}</td>
                  </tr>

                </tbody>


              );
            })
          }
        </table>
      </div>
    );

  }
}


export default class LocalizaBox extends Component {
  atualizaListagem(novaLista) {
    this.setState({ lista: novaLista });
  }
  constructor() {
    super();
    this.state = { lista: [] };
    this.atualizaListagem = this.atualizaListagem.bind(this);

  }

  componentDidMount() {


    PubSub.subscribe('atualiza-lista-autores', function (topico, novaLista) {
      var array = [{}]

      for (var variavel in novaLista["pessoas"]) {
        // console.log(novaLista);
        // console.log(novaLista[variavel]);

        array.push(novaLista[variavel]);
      }


      this.setState({ lista: novaLista });


    }.bind(this));
  }

  render() {


    return (
      <div>
        <Localiza />
        <TabelaCadastro lista={this.state.lista} />
      </div>
    );


  }
}


