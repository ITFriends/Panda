import React, { Component } from 'react';

export class ListHouses extends Component {
    static displayName = ListHouses.name;

    constructor(props) {
        super(props);
        this.state = { houses: [], loading: true };
    }

    componentDidMount() {
        this.getHouses();
    }

    static renderHouses(houses) {
        return (
            <div className="row">
                {houses.map(house =>
                    <div key={house.id} className="col-lg-4 col-md-6 col-xs-12 mt-5 text-center">
                        <img src={'pictures/' + house.picture} className="img-fluid" />
                        <h5>{house.price} uah/day</h5>
                     </div>
                 )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ListHouses.renderHouses(this.state.houses);

        return (
            <div>
                <h1>Our houses</h1>
                <hr />
                {contents}
            </div>
        );
    }

    async getHouses() {
        const response = await fetch('api/house');
        const data = await response.json();
        this.setState({ houses: data, loading: false });
    }
}