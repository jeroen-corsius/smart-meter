import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { withStyles } from 'material-ui/styles';
import Card, { CardContent } from 'material-ui/Card';
import Typography from 'material-ui/Typography';
import moment from 'moment';
import { BarChart, Bar } from 'recharts';

const classes = theme => ({
  card: {
    minWidth: 300,
    borderRadius: 8,
  },
  cardContent: {
    padding: 0
  },
  colorPart: {
    padding: 16,
    borderRadius: '8px 8px 0px 0px',
    color: 'white',
    textAlign: 'center',
    height: 180
  },
  bottomPart: {
    margin: '16'
  },
  description: {
    color: 'lightgrey',
    padding: '16px 0px 0px 16px'
  },
  title: {
    color: 'white',
    fontSize: 22,
    fontWeight: 'bold'
  },
  subTitle: {
    color: '#ed9f76',
  },
  value: {
    fontWeight: 'bold',
    fontSize: 40,
    display: 'inline',
    paddingLeft: 16
  },
  pos: {
    color: theme.palette.text.secondary,
    display: 'inline',
    paddingLeft: 5
  },
});

class LiveCard extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isConsuming: this.determineIsConsuming(props.consuming)
    };
  }

  componentDidMount() {
    this.createStateFromProps(this.props);
  }

  componentWillReceiveProps(props) {
    this.createStateFromProps(this.props);
  }

  determineIsConsuming(actualConsuming) {
    return actualConsuming > 0;
  }

  createStateFromProps() {
    this.setState({
      backgroundColor: this.determineBackgroundColor(),
      title: this.determineTitle(),
      chartDate: this.createChartData(this.props.last5MinutesData),
      description: this.determineDescription(),
      actualValue: this.determineActualValue(this.props.consuming, this.props.delivering),
      actualTimestamp: this.props.timestamp
    });
  }

  determineBackgroundColor() {
    if (this.state.isConsuming) {
      return '#FF5722';
    }
  
    return '#8BC34A';
  }

  determineTitle() {
    if (this.state.isConsuming) {
      return "Consuming";
    }
  
    return "Producing";
  }

  createChartData(data) {
    return data.map(item => {
      const itemConsuming = item.electrictyConsumedActual > 0;
      const itemValue = itemConsuming ? item.electrictyConsumedActual : item.electricityDeliveredActual;

      return { value: itemValue };
    });
  }

  determineDescription() {
    if (this.state.isConsuming) {
      return "Total energy consumption at this moment";
    }
  
    return "Total energy production at this moment";
  }

  determineActualValue(consuming, delivering) {
    let actualValue = consuming;

    if (!this.state.isConsuming) {
      actualValue = delivering;
    }
  
    return Number(actualValue).toFixed(3);
  }

  render() {
    return (
      <div>
        <Card className={classes.card}>
          <CardContent className={classes.cardContent}>
            <div className={classes.colorPart} style={{ backgroundColor: this.state.backgroundColor }}>
              <Typography className={classes.title}>{this.state.title}</Typography>
              <Typography className={classes.subTitle}>{moment(this.state.actualTimestamp).format('DD-MM-YYYY')}</Typography>
              <BarChart width={268} height={130} data={this.state.chartDate}>
                <Bar dataKey="value" fill='#000000' barSize={4} />
              </BarChart>
            </div>
            <Typography className={classes.description}>{this.state.description}</Typography> 
            <Typography className={classes.value}>{this.state.actualValue}</Typography>
            <Typography className={classes.pos} align="center">kW</Typography>
          </CardContent>
        </Card>
      </div>
    );
  }
}

LiveCard.propTypes = {
  classes: PropTypes.object.isRequired,
  timestamp: PropTypes.instanceOf(moment).isRequired,
  consuming: PropTypes.number.isRequired,
  delivering: PropTypes.number.isRequired,
  last5MinutesData: PropTypes.array.isRequired,
};

export default withStyles(classes)(LiveCard);