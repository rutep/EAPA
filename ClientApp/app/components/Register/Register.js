import React, { Component } from 'react';
import './style.scss';

class Register extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: '',
      email: '',
      password: '',
      listinn: [],
      message: '',
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleListinn = this.handleListinn.bind(this);
  }

  handleListinn = () => {
    this.state.listinn.push({ name: this.state.name });
    this.setState(this.state.listinn);
  };

  // Ath name=email þarf að vera sama í target value
  handleChange(e) {
    this.setState({
      [e.target.name]: e.target.value,
      [e.target.email]: e.target.value,
      [e.target.password]: e.target.value,
    });
  }

  async handleSubmit(e) {
    // alert('A name was submitted: ' + this.state.email);
    e.preventDefault();
    const response = await fetch('http://localhost:8080/api/Users', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        username: this.state.name,
        password: this.state.password,
        email: this.state.email,
      })
    });
    const json = await response.json();

    try {
      if (json.error.message) {
        this.setState({
          message: json.error.message,
        });
      }
    } catch {
      this.setState({
        message: 'New use has bin created',
      });
    }

    console.log(this.state.name, this.state.password, this.state.email);
  }

  render() {
    return (
      <div className="form-body">

        <form onSubmit={this.handleSubmit}>

          <div className="form-group">
            <label>
            Name:
            </label>
            <input
              type="text"
              name="name"
              className="form-control"
              value={this.state.value}
              onChange={this.handleChange}
            />

          </div>

          <div className="form-group">
            <label>
                Email:
            </label>
            <input
              type="text"
              name="email"
              className="form-control"
              value={this.state.value}
              onChange={this.handleChange}
            />

          </div>

          <div className="form-group">
            <label>
              password:
            </label>
            <input
              type="text"
              name="password"
              className="form-control"
              value={this.state.value}
              onChange={this.handleChange}
            />

          </div>

          <input
            type="submit"
            value="Submit"
            className="btn btn-primary"
            onClick={this.handleListinn}
          />
        </form>
      </div>
    );
  }
}

export default Register;
