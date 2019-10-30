import React, { Component } from 'react';
import $ from 'jquery';
import InputCustomizado from './componentes/InputCustomizado';
import PubSub from 'pubsub-js';
export class FormularioCadastro extends Component {

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
      url: "http://localhost:51751/V1/LocalizacaoDoAmigo",
      contentType: 'application/json',
      crossDomain: true,
      dataType: 'json',
      type: 'post',
      data: JSON.stringify({ Nome: this.state.Nome, X: this.state.X, Y: this.state.Y }),
      headers: {
        'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJWYWxkaXIgRmVycmVpcmEiLCJqdGkiOiI1OTc1NWFkZC04YTc2LTQ0YTYtOTJlZS01YmMwMjc3NzQwYTgiLCJVc3VhcmlvQVBJTnVtZXJvIjoiMSIsImV4cCI6NjE1NzIxODgyMzAsImlzcyI6IlRlc3RlLlNlY3VyaXJ5LkJlYXJlciIsImF1ZCI6IlRlc3RlLlNlY3VyaXJ5LkJlYXJlciJ9.9n-Xbe1fiOxDxVkIXipzVHapj0Olcl64RFAQ8EYmXtY'
      },
      success: function (resposta) {
        console.log(resposta);
        if (resposta.nome) {
          PubSub.publish('atualiza-lista-autores', resposta);
        }
        else {
          alert(resposta.Erro);
        }
      }.bind(this),
      error: function (resposta) {
        console.log(resposta);
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
          <InputCustomizado id="nome" type="text" name="nome" value={this.state.Nome} onChange={this.setNome} label="Nome" />
          <InputCustomizado id="X" type="text" name="X" value={this.state.X} onChange={this.setX} label="X" />
          <InputCustomizado id="idade" type="text" name="Y" value={this.state.Y} onChange={this.setY} label="Y" />
          <div className="pure-control-group">
            <label></label>
            <button type="submit" className="pure-button pure-button-primary">Gravar</button>
          </div>
        </form>
        <TabelaCadastro lista={this.state.lista} />
      </div>
    );
  }

}
export class TabelaCadastro extends Component {

  render() {
    return (
      <div>
        {

          this.props.lista.map(function (lista) {
            return (
              <div>
                <h1>Novo Amigo cadastrado! </h1>
                <table className="pure-table">

                  <thead>
                    <tr>
                      <th>Nome</th>
                      <th>X</th>
                      <th>Y</th>
                    </tr>
                  </thead>
                  <tbody>

                    <tr key={lista.id}>
                      <td>{lista.nome}</td>
                      <td>{lista.x}</td>
                      <td>{lista.y}</td>
                    </tr>

                  </tbody>
                </table>
              </div>
            );
          })
        }
      </div>
    );

  }
}


export default class CadastroBox extends Component {
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
      novaLista = [{ nome: novaLista.nome, x: novaLista.x, y: novaLista.y }];

      this.setState({ lista: novaLista });


    }.bind(this));
  }

  render() {


    return (
      <div>
        <FormularioCadastro />
        <TabelaCadastro lista={this.state.lista} />
      </div>
    );


  }
}


