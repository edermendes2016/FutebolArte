var ClubeGridRow = React.createClass({
    render: function () {
        return (
            <tr>
                <td>{this.props.item.Nome}</td>
                <td>{this.props.item.Sigla}</td>
                <td>{this.props.item.GF}</td>
                <td>{this.props.item.GS}</td>
                <td>{this.props.item.Pontos}</td>
               
            </tr>
        );
    }
});

var ClubeGridTable = React.createClass({
    getInitialState: function () {
        return {
            items: []
        }
    },
    componentDidMount: function () {    
        $.get(this.props.dataUrl, function (data) {
            if (this.isMounted()) {
                this.setState({
                    items: data
                });
            }
        }.bind(this));
    },
    render: function () {
        var rows = [];
        this.state.items.forEach(function (item) {
            rows.push(<ClubeGridRow key={item.Id} item={item} />);
        });
        return (<table className="table table-bordered table-responsive">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Sigla</th>
                    <th>Gols Feitos</th>
                    <th>Gols Sofridos</th>
                    <th>Pontost</th>
                </tr>
            </thead>
            <tbody>
                {rows}
              
            </tbody>
        </table>);
    }
});
ReactDOM.render(
    <ClubeGridTable dataUrl="/Clube/getClubeData" />,
    document.getElementById('griddata')
);

