function dijkstra(graph, source) {
    const distances = {};
    for (const node in graph) {
      distances[node] = Infinity;
    }
    distances[source] = 0;
  
    const unvisitedNodes = new Set(Object.keys(graph));
    let currentNode = source;
  
    while (unvisitedNodes.size) {
      for (const neighbor in graph[currentNode]) {
        const distance = distances[currentNode] + graph[currentNode][neighbor];
        if (distance < distances[neighbor]) {
          distances[neighbor] = distance;
        }
      }
  
      unvisitedNodes.delete(currentNode);
      let nextNode = null;
      let nextNodeDistance = Infinity;
      for (const node of unvisitedNodes) {
        if (distances[node] < nextNodeDistance) {
          nextNode = node;
          nextNodeDistance = distances[node];
        }
      }
      currentNode = nextNode;
    }
  
    return distances;
  }