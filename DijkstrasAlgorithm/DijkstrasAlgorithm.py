from pythonds.graphs import Graph, PriorityQueue, Vertex
from pythonds.basic.queue import Queue

def buildGraph():
    g = Graph()
    
    #g.addEdge('u','v', 2)
    #g.addEdge('u','x', 1)
    #g.addEdge('v','w', 3)
    #g.addEdge('w','z', -5)
    #g.addEdge('u','w', 5)
    #g.addEdge('v','x', 2)
    #g.addEdge('x','y', 1)
    #g.addEdge('y','z', 1)
    #g.addEdge('x','w', 3)
    #g.addEdge('y','w', 1)

    #Fig 4.14 from S Dasgupta
    g.addEdge('s','a', 10)
    g.addEdge('s','g', 8)
    g.addEdge('g','f', 1)
    g.addEdge('a','e', 2)
    g.addEdge('f','a', -4)
    g.addEdge('f','e', -1)
    g.addEdge('e','b',-4)
    g.addEdge('b','a', 1)
    g.addEdge('b','c', 1)
    g.addEdge('c','d', 3)
    g.addEdge('d','e', -1)

    
    pq = PriorityQueue()

    start = g.getVertex('s')
    start.setDistance(0)
    pq.buildHeap([(v.getDistance(),v) for v in g])
    while not pq.isEmpty():
        currentVert = pq.delMin()
        for nextVert in currentVert.getConnections():
            newDist = currentVert.getDistance() \
                    + currentVert.getWeight(nextVert)
            if newDist < nextVert.getDistance():
                nextVert.setDistance( newDist )
                nextVert.setPred(currentVert)
                pq.decreaseKey(nextVert,newDist)

    return g

x = buildGraph()
y = x