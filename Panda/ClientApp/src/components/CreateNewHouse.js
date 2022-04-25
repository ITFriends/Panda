import React, { Component } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

export class CreateNewHouse extends Component {
    static displayName = CreateNewHouse.name;

    constructor(props) {
      super(props);
        this.state = {
            number: '1',
            price: '5',
            selectedFile: null,
            selectedFileName: '',
            uploadResult: {
                status: 'not uploaded'
            }
        }

        this.onInputChange = this.onInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.uploadFile = this.uploadFile.bind(this);
    }

    onInputChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    handleSubmit(event) {
        this.sendHouseData();
    }

    onUploadChange = event => {
        debugger;
            this.setState({
                selectedFile: event.target.files[0],
                selectedFileName: event.target.files[0].name
            })
        };

    async uploadFile() {
        const formData = new FormData();
        formData.append('file', this.state.selectedFile);

        const response = await fetch("api/admin/house/upload",
            {
                method: 'POST',
                body: formData
            });

        const data = await response.json();

        this.setState({
            uploadResult: data
        })
    }

    render() {
        return (
            <Form onSubmit = { this.handleSubmit }>
                <Form.Group className="mb-3">
                    <Form.Label>Number</Form.Label>
                    <Form.Control type="number" placeholder="Number" value={this.state.number} name="number" onChange={this.onInputChange} />
                    <Form.Text className="text-muted">
                        This is the number of cabin
                    </Form.Text>
                </Form.Group>

                <Form.Group className="mb-3">
                    <Form.Label>Price (in UAH)</Form.Label>
                    <Form.Control type="number" placeholder="Enter price" value={this.state.price} name="price" onChange={this.onInputChange}  />
                    <Form.Text className="text-muted">
                        This is the price for a daily rental of cabin
                    </Form.Text>
                </Form.Group>

                <Form.Label>Family</Form.Label>
                <Form.Select aria-label="Select Family">
                    <option>Not selected</option>
                    <option value="0">Dog</option>
                    <option value="1">Cat</option>
                    <option value="2">Hamster</option>
                    <option value="3">Parrot</option>
                    <option value="4">Lizard</option>
                    <option value="5">Spider</option>
                </Form.Select>

                <Form.Label className="mt-5">Size (in meters)</Form.Label>
                <Form.Group className="mb-1">
                    <Form.Label>Length</Form.Label>
                    <Form.Control type="number" placeholder="Enter length" onChange={this.onInputChange} />
                </Form.Group>
                <Form.Group className="mb-1">
                    <Form.Label>Width</Form.Label>
                    <Form.Control type="number" placeholder="Enter width" />
                </Form.Group>
                <Form.Group className="mb-1">
                    <Form.Label>Height</Form.Label>
                    <Form.Control type="number" placeholder="Enter height" />
                </Form.Group>


                <Form.Label className="mt-5">Select status</Form.Label>
                <Form.Select aria-label="Select status">
                    <option>Not selected</option>
                    <option value="0">Free</option>
                    <option value="1">Occupied</option>
                </Form.Select>

                {/*<Form.Group controlId="formFile" className="mt-5">*/}
                {/*    <Form.Label>Load picture of a new cabin</Form.Label>*/}
                {/*    <Form.Control type="file" />*/}
                {/*</Form.Group>*/}


                <div className="mt-5 d-flex">
                    <div className="custom-file w-50 mr-2">
                        <Form.Control type="file" name="file" onChange={this.onUploadChange} className="custom-file-input" />
                        <label className="custom-file-label" htmlFor="customFile"> {this.state.selectedFileName}</label>
                    </div>
                    <button type="button" className="btn btn-success" onClick={this.uploadFile}>Upload</button>
                </div>
                <p>Status: {this.state.uploadResult.status}</p>
            </Form>
        );
    }

    async sendHouseData() {
        debugger;
        const formData = new FormData();
        formData.append("number", this.state.number);
        formData.append("price", this.state.price);

        const response = await fetch('api/admin/house/create',
            {
                method: 'POST',
                body: formData
            });

        const data = await response.json();
    }
}
