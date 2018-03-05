import React, { Component } from 'react';
import Axios from 'axios';
import LiveCard from './components/LiveCard';
import Grid from 'material-ui/Grid';
import moment from 'moment';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      timestamp: moment(),
      actualConsumed: 0,
      actualDelivered: 0,
      last5MinutesData: []
    };

    this.retrieveActualData();
    this.retrieveLast5MinutesData();

    setInterval(() => this.retrieveActualData(), 10000);
    setInterval(() => this.retrieveLast5MinutesData(), 10000);
  }

  retrieveActualData() {
    Axios.get("http://192.168.178.28:5000/api/electricity/current")
      .then(response => {
        const timestamp = moment(response.data.timestamp);
        const actualConsumed = response.data.electrictyConsumedActual;
        const actualDelivered = response.data.electricityDeliveredActual;

        this.setState({ timestamp, actualConsumed, actualDelivered});
      });
  }

  retrieveLast5MinutesData() {
    Axios.get("http://192.168.178.28:5000/api/electricity/Last5Minutes")
      .then(response => {
        this.setState({ last5MinutesData: response.data });
      })
  }

  render() {
    return (
      <div style={{ padding: 12 }}>
        <Grid container justify="center" spacing={24}>
          <Grid item>
            <LiveCard
              timestamp={this.state.timestamp}
              consuming={this.state.actualConsumed}
              delivering={this.state.actualDelivered}
              last5MinutesData={this.state.last5MinutesData} />
          </Grid>
        </Grid>
      </div>
    );
  }
}

export default App;
