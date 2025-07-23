import React, { Component } from 'react'
import MetricService from '../services/metric-service';
import { withNavigation } from './with-navigation';


class MetricCreateComponent extends Component {
    constructor(props) {
        super(props)

        this.state = {
            // step 2
            id: this.props.params?.id || '',

                    name: '' ,
                
                    category_id: '' ,
                
                    uom_id: '' 
                            
        }
                    
                    this.changeIdHandler = this.changeIdHandler.bind(this);
                                    
                    this.changeNameHandler = this.changeNameHandler.bind(this);
                                    
                    this.changeCategoryIdHandler = this.changeCategoryIdHandler.bind(this);
                                    
                    this.changeUomIdHandler = this.changeUomIdHandler.bind(this);
                        this.saveOrUpdateMetric = this.saveOrUpdateMetric.bind(this);
    }

    // step 3
    componentDidMount(){

        

        // step 4
        if(this.state.id === '_add'){
            return
        }else{
            console.log ("Metric componentDidMount() ID= " + this.state.id )
            MetricService.getMetricById(this.state.id).then( (res) =>{
                let metric = res.data;
                this.setState({

                            id: metric.id ,
                        
                            name: metric.name ,
                        
                            category_id: metric.category_id ,
                        
                            uom_id: metric.uom_id 
                        
                });
            });
        }   
        
       ;
    }
    saveOrUpdateMetric = (e) => {
        e.preventDefault();
        let metric = {

                   id: this.state.id === '_add' ?  '0' : this.state.id ,
                            
                    name: this.state.name , 
                            
                    category_id: this.state.category_id , 
                            
                    uom_id: this.state.uom_id  
                        };
        console.log('metric => ' + JSON.stringify(metric));

        // step 5
        if(this.state.id === '_add'){
            MetricService.createMetric(metric).then(res =>{
                this.props.navigate('/metric');
            });
        }else{
            MetricService.updateMetric(metric, this.state.id).then( res => {
                this.props.navigate('/metric');
            });
        }
    }
    

        changeIdHandler= (event) => {
            this.setState({id: event.target.value});
        }
        
        changeNameHandler= (event) => {
            this.setState({name: event.target.value});
        }
        
        changeCategoryIdHandler= (event) => {
            this.setState({category_id: event.target.value});
        }
        
        changeUomIdHandler= (event) => {
            this.setState({uom_id: event.target.value});
        }
            cancel(){
        this.props.navigate('/metric');
    }

    getTitle(){
        if(this.state.id === '_add'){
            return <h3 className="text-center">Add Metric</h3>
        }else{
            return <h3 className="text-center">Update Metric</h3>
        }
    }
    render() {
        return (
            <div>
                <br></br>
                   <div className = "container">
                        <div className = "row">
                            <div className = "card col-md-6 offset-md-3 offset-md-3">
                                {
                                    this.getTitle()
                                }
                                <div className = "card-body">
                                    <form>
                                        
                    
                                            <div className = "form-group">
                                            <br/>
                                            <label> ID: </label>
                                            <input placeholder="" name="id" className="form-control" 
                                                value={this.state.id} onChange={this.changeIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Name: </label>
                                            <input placeholder="" name="name" className="form-control" 
                                                value={this.state.name} onChange={this.changeNameHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Category: </label>
                                            <input placeholder="" name="category_id" className="form-control" 
                                                value={this.state.category_id} onChange={this.changeCategoryIdHandler}/>
                                            </div>
                                                                
                                            <div className = "form-group">
                                            <br/>
                                            <label> Unit: </label>
                                            <input placeholder="" name="uom_id" className="form-control" 
                                                value={this.state.uom_id} onChange={this.changeUomIdHandler}/>
                                            </div>
                                                                                    <button className="btn btn-success" onClick={this.saveOrUpdateMetric}>Save</button>
                                        <button className="btn btn-danger" onClick={this.cancel.bind(this)} style={{marginLeft: "10px"}}>Cancel</button>
                                    </form>
                                </div>
                            </div>
                        </div>

                   </div>
            </div>
        )
    }
}

export default withNavigation(MetricCreateComponent);