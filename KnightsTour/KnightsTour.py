from pythonds.graphs import Graph

def genLegalMoves(x,y,bdSize):
    newMoves = []
    moveOffsets = [(-1,-2),(-1,2),(-2,-1),(-2,1),
                   ( 1,-2),( 1,2),( 2,-1),( 2,1)]
    for i in moveOffsets:
        newX = x + i[0]
        newY = y + i[1]
        if legalCoord(newX,bdSize) and \
                        legalCoord(newY,bdSize):
            newMoves.append((newX,newY))
    return newMoves

def legalCoord(x,bdSize):
    if x >= 0 and x < bdSize:
        return True
    else:
        return False


def knightTour(n, path, currentVertex, limit):
    done = False
    currentVertex.setColor("grey")
    print("Adding " + str(currentVertex.id))
    path.append(currentVertex)

    if n < limit:
            for i in currentVertex.getConnections():
                if (i.getColor() == "white"):
                    done = knightTour(n + 1, path, i, limit)
            if not done:
                currentVertex.setColor("white")
                path.remove(currentVertex)
                print("Removing " + str(currentVertex.id))
                #pop(currentVertex)
    else:
        return True

    return done

def knightGraph(bdSize):
    ktGraph = Graph()
    for row in range(bdSize):
       for col in range(bdSize):
           nodeId = posToNodeId(row,col,bdSize)
           newPositions = genLegalMoves(row,col,bdSize)
           for e in newPositions:
               nid = posToNodeId(e[0],e[1],bdSize)
               ktGraph.addEdge(nodeId,nid)
    
    path = []
    limit = bdSize * bdSize
    currentVertex = ktGraph.getVertex(0)
    x = knightTour(0, path, currentVertex, limit)
    y = path

def posToNodeId(row, column, board_size):
    return (row * board_size) + column

knightGraph(5)