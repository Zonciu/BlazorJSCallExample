function setup() {
    const ticks = [0, 1000 / 2000, 1500 / 2000, 1];
    const color = ['#F4664A', '#FAAD14', '#30BF78'];
    window.demo.charts.temp = {
        titleStyle: ({percent}) => {
            return {
                fontSize: '20px',
                offsetY: '20px',
                color: percent < ticks[1] ? color[0] : percent < ticks[2] ? color[1] : color[2],
            };
        }
    }
    window.demo.dotnetTest = async function(func) {
        console.log(await func(Date.now()));
    }
}

setup();